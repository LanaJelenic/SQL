import React, { Component } from "react";
import { Button, Container, Table } from "react-bootstrap";
import KnjigaDataService from "../../services/knjiga.service";
import { NumericFormat } from "react-number-format";
import { Link } from "react-router-dom";
import {FaEdit, FaTrash} from "react-icons/fa"


export default class Knjige extends Component{

    constructor(props){
        super(props);

        this.state = {
            knjige: []
        };

    }

    componentDidMount(){
        this.dohvatiKnjige();
    }

    async dohvatiKnjige(){

        await KnjigaDataService.get()
        .then(response => {
            this.setState({
                knjige: response.data
            });
            console.log(response.data);
        })
        .catch(e =>{
            console.log(e);
        });
    }

    async obrisiKnjigu(id_knjige){
        const odgovor = await KnjigaDataService.delete(id_knjige);
        if(odgovor.ok){
            this.dohvatiKnjige();
        }else{
            alert(odgovor.poruka);
        }
    }


    render(){

        const { knjige } = this.state;

        return (
            <Container>
               <a href="/knjige/dodaj" className="btn btn-success gumb">
                Dodaj novu knjigu
               </a>
                
               <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Naslov</th>
                        <th>Ime_Autora</th>
                        <th>Prezime_Autora</th>
                        <th>Sazetak</th>
                        <th>Br_stranica</th>
                    </tr>
                </thead>
                <tbody>
                   { knjige && knjige.map((knjiga,index) => (

                    <tr key={index}>
                        <td>{knjiga.naslov}</td>
                        <td>{knjiga.ime_Autora}</td>
                        <td>{knjiga.prezime_Autora}</td>
                        <td className="broj">{knjiga.br_stranica}</td>
                        
                        
                        <td>
                            <Link className="btn btn-primary gumb"
                            to={`/knjige/${knjiga.id_knjige}`}>
                                <FaEdit />
                            </Link>

                            <Button variant="danger" className="gumb"
                            onClick={()=>this.obrisiKnjigu(knjiga.id_knjige)}>
                                <FaTrash />
                            </Button>
                        </td>
                    </tr>

                   ))}
                </tbody>
               </Table>



            </Container>


        );
    }
}