$(document).foundation();

let podaci=[];
let trenutniClan=0;

function ucitajPodatke(){
    $.ajax( 'http://localhost:5232/api/v1/Clan' ,   // request url
    {
        success: function (data, status, xhr) {// success callback function
           // console.log(data);
           podaci = data;
           $('#podaci').html('');
           for(let i=0;i<data.length;i++){
            $('#podaci').append('<li>' + data[i].br_iskaznice + 
            ' <a class="brisi" href="#" id="s_' + data[i].id + '">X</a>' + 
            ' <a class="promjena" href="#" id="p_' + data[i].id + '">P</a>' + 
            '</li>');
           }
           definirajDogadaje();
    }
});
}

ucitajPodatke();


function definirajDogadaje(){
    $('.brisi').off('click');
    $('.brisi').click(function(){

        const element = $(this);
       // console.log(element);
        const sifra = element.attr('id').split('_')[1];
        console.log('Brišem: ' + id);

        $.ajax( 'http://localhost:5232/api/v1/Clan'  + id, {
        type: 'DELETE',  // http method
        success: function (data, status, xhr) {
           element.parent().remove();
        },
        error: function (e) {
                console.log(e);
                alert(e.responseJSON);
        }
    });
        return false;
    });


    $('.promjena').off('click');
    $('.promjena').click(function(){
        const element = $(this);
        // console.log(element);
         const sifra = element.attr('id').split('_')[1];
        //console.log(sifra);
        trenutniSmjer = id;
        for(let i=0;i<podaci.length;i++){
            const s = podaci[i];
            if(s.id==id){
                $('#ime').val(s.ime);
                $('#prezime').val(s.prezime);
                $('#br_iskaznice').val(s.br_iskaznice);
                
                if(s.status){
                    $('#status').attr('checked','checked');
                }else{
                    $('#status').removeAttr('checked');
                }
                break;
            }
        }

        return false;
    });
}


$('#dodaj').click(function(){

    const ime = $('#ime').val();
    if(ime.trim().length==0){
        ime=0;
    }

    const br_iskaznice = $('#br_iskaznice').val();
    if(br_iskaznice.trim().length==0){
        br_iskaznice=0;
    }

    const prezime = $('#prezime').val();
    if(prezime.trim().length==0){
        prezime=0;
    }

    const status = $('#status').is(":checked")

    const clan = { 
        ime: $('#ime').val(), 
        br_iskaznice: br_iskaznice,
        prezime:  prezime,
        status:status};

    $.ajax( 'http://localhost:5232/api/v1/Clan' , {
        type: 'POST',  // http method
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(clan),  // data to submit
        success: function (clan, status, xhr) {
            console.log(podaci);
            podaci.push(clan);
            $('#podaci').append('<li>' + $('#ime').val() + 
            ' <a class="brisi" href="#" id="s_' + clan.id + '">X</a>' + 
            ' <a class="promjena" href="#" id="p_' + clan.id + '">P</a>' + 
            '</li>');
            definirajDogadaje();
        },
        error: function (e) {
                //alert(errorMessage);
                //console.log(e.responseJSON.errors);
                const greske = e.responseJSON.errors;
                let poruka='';
                for(svojstvo in greske){
                    //console.log(varijabla);
                    //console.log(`${g[varijabla]}`);
                    poruka += `${greske[svojstvo]}` + '\n';
                }
                alert(poruka);

        }
    });

    return false;
});



$('#promjeni').click(function(){

    if(trenutniClan==0){
        alert('Prvo odaberite smjer za promjenu');
        return;
    }


    const ime = $('#ime').val();
    if(ime.trim().length==0){
       ime=0;
    }

    const prezime = $('#prezime').val();
    if(prezime.trim().length==0){
        prezime=0;
    }

    const br_iskaznice = $('#br_iskaznice').val();
    if(br_iskaznice.trim().length==0){
        br_iskaznice=0;
    }

    const status = $('#status').is(":checked")

    
    const clan = { 
        ime: $('#ime').val(), 
        br_iskaznice: br_iskaznice,
        prezime:  prezime,
        status:status};

    $.ajax( 'http://localhost:5232/api/v1/Clan'  + trenutniClan, {
        type: 'PUT',  // http method
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(clan),  // data to submit
        success: function (clan, status, xhr) {
           // trebalo bi podvaliti na postojeći zapis.
           ucitajPodatke();
        },
        error: function (e) {
                //alert(errorMessage);
                //console.log(e.responseJSON.errors);
                const greske = e.responseJSON.errors;
                let poruka='';
                for(svojstvo in greske){
                    //console.log(varijabla);
                    //console.log(`${g[varijabla]}`);
                    poruka += `${greske[svojstvo]}` + '\n';
                }
                alert(poruka);

        }
    });

    return false;
});