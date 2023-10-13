import http from "../http-common";

class KnjigaDataService{

    async get(){
        return await http.get('/Knjiga');
    }
    async getByID(id_knjige){
        return await http.get('/knjiga/'+ id_knjige);
    }

    async delete(id_knjige){
        const odgovor=await http.delete('/Knjiga/'+ id_knjige)
        .then(response=>{
            return{ok:true, poruka:'Obrisano uspjesno'};
        })
        .catch(e=>{
            return{ok:false, poruka:e.response.data};
        });
        return odgovor;
    }

    async post(knjiga){
        const odgovor=await http.post('/knjiga',knjiga)
        .then(response=>{
            return{ok:true, poruka:'Uspjesno unesena knjiga'};
        })
        .catch(error=>{
            return{ok:false, poruka:error.response.data};
        });
        return odgovor;
    }

    async put(id_knjige,knjiga){
        const odgovor=await http.put('/knjiga/'+id_knjige,knjiga)
        .then(response=>{
            return{ok:true, poruka:'Knjiga uspjesno promijenjena'};

        })
        .catch(error=>{
            return{ok:false, poruka:error.response.data};
        });
        return odgovor;
    }

}

export default new KnjigaDataService();