import http from '../http-common';

class ClanDataService{

    async getAll(){
        return await http.get('/clan');
    }

    async getByID(id_clana){
        return await http.get('/clan/'+ id_clana);
    }

    async post(clan){
        const odgovor=await http.post('/clan',clan)
        .then(response =>{
            return{ok:true, poruka:'Unjeo clana'};
        })
        .catch(error=>{
            console.log(error.response);
            return{ok:false, poruka:error.response.data};
        });
        return odgovor;
    }

   async put(id_clana,clan){
    const odgovor= await http.put('/clan/'+ id_clana,clan)
    .then(response =>{
        return{ok:true, poruka:'Promijenio clana'};
    })
    .catch(error=>{
        console.log(error.response);
        return{ok:false, poruka:error.response.data};
    });
    return odgovor;
   }

   async delete(id_clana){
    const odgovor=await http.delete('/clan/'+id_clana)
    .then(response=>{
        return{ok:true, poruka:'Obrisano uspjesno'};
    })
    .catch(error=>{
        console.log(error);
        return{ok:false,poruka:error.response.data};
    });
    return odgovor;
   }

}

export default new ClanDataService();