import http from "../http-common";

class EvidencijaDataService{

    async getAll(){
        return await http.get('/Evidencija');
    }

    async getByID(id_posudbe){
        return await http.get('/Evidencija/'+ id_posudbe);
    }

    async getKnjige(id_knjige)
    {
        return await http.get('/Evidencija/Id:int/knjige?id_knjige='+id_knjige)
    }

    async post(evidencija){
        console.log('Dodajem u bazu' + evidencija);
        const odgovor=await http.post('/Evidencija',evidencija)
        .then(response=>{
            return {ok:true,poruka:'Evidencija posudbe je uspjesno unesena!'};
        })
        .catch(error=>
            {console.log(error.response);
            return{ok:false, poruka: error.response.data};
            });
            return odgovor;
    }

    async delete(id_posudbe)
    {
         const odgovor=await http.delete('/Evidencija?Id_posudbe='+ id_posudbe)
         .then(response=>
            {
                return{ok:true, poruka: 'Evidencija je obrisana uspjesno!'};
            })
            .catch(error=>
                {
                    console.log(error);
                    return {ok:false, poruka: error.response.data};
                });
                return odgovor;
    }

    async obrisiKnjigu(id_posudbe,id_knjige)
    {
        const odgovor=await http.delete('/obrisi/'+id_knjige +'?id_posudbe='+ id_posudbe)
        .then(response=>
            {
                return {ok:true, poruka: 'Obrisao uspješno'};
            })
            .catch(error => {
                console.log(error);
                return {ok:false, poruka: error.response.data};
              });
        
              return odgovor;
    }

    async dodajKnjigu(id_posudbe,id_knjige){
    
        const odgovor = await http.post('/dodaj' + id_knjige + '?Id_posudbe='+ id_posudbe)
           .then(response => {
             return {ok:true, poruka: 'Uspjesno dodano'};
           })
           .catch(error => {
             console.log(error);
             return {ok:false, poruka: error.response.data};
           });
     
           return odgovor;
         }

}

export default new EvidencijaDataService();