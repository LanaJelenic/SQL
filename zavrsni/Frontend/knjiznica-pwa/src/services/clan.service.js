import http from '../http-common';

class ClanDataService{

    async getAll(){
        return await http.get('/clan');
    }

    async getByID(Id_clana){
        return await http.get('/clan/'+ Id_clana);
    }

    async post(clan){
        const odgovor=await http.post('/Clan',clan)
        .then(response =>{
            return{ok:true, poruka:' Clan uspješno unesen!'};
        })
        .catch(error=>{
            console.log(error.response);
            return{ok:false, poruka:error.response.data};
        });
        return odgovor;
    }

   async put(Id_clana,clan){
    const odgovor= await http.put('/Clan?Id_clana='+ Id_clana,clan)
    .then(response =>{
        return{ok:true, poruka:'Član je uspješno promijenjen'};
    })
    .catch(error=>{
        console.log(error.response);
        return{ok:false, poruka:error.response.data};
    });
    return odgovor;
   }

   async delete(Id_clana){
    const odgovor=await http.delete('/Clan?Id_clana='+Id_clana)
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