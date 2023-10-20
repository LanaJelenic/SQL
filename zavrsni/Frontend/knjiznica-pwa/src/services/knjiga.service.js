import http from "../http-common";

class KnjigaDataService{

    async getAll(){
        return await http.get('/knjiga');
    }
    async getByID(id_knjige){
        return await http.get('/knjiga/'+ id_knjige);
    }

    async delete(id_knjige){
        const odgovor=await http.delete('/Knjiga?Id_knjige='+ id_knjige)
        .then(response=>{
            return{ok:true, poruka:'Obrisano uspješno!'};
        })
        .catch(e=>{
            return{ok:false, poruka:e.response.data};
        });
        return odgovor;
    }

    async post(knjiga){
        const odgovor=await http.post('/Knjiga',knjiga)
        .then(response=>{
            return{ok:true, poruka:'Uspješno unesena knjiga'};
        })
        .catch(error=>{
            return{ok:false, poruka:error.response.data};
        });
        return odgovor;
    }

    async put(id_knjige,knjiga){
        const odgovor=await http.put('/Knjiga?Id_knjige='+id_knjige,knjiga)
        .then(response=>{
            return{ok:true, poruka:'Knjiga uspješno promijenjena!!'};

        })
        .catch(error=>{
            return{ok:false, poruka:error.response.data};
        });
        return odgovor;
    }
    async postaviSliku(id_knjige,slika)
    {
        const odgovor= await http.put('/Knjiga/postaviSliku/'+id_knjige,slika)
        .then(response =>{
            return{ok:true,poruka:'Postavi sliku'};
        })
        .catch(error =>{
            console.log(error);
            return{ok:false,poruka:error.response.data};
        })
        return odgovor;
    }

}

export default new KnjigaDataService();