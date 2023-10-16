import React,{Component} from "react";
import KnjigaDataService from "../../services/knjiga.service";
import  Container  from "react-bootstrap/Container";
import  Button  from "react-bootstrap/Button";
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";

export default class DodajKnjigu extends Component{

    constructor(props){
        super(props);
        this.dodajKnjigu= this.dodajKnjigu.bind(this);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    async dodajKnjigu(knjiga){
        const odgovor= await KnjigaDataService.post(knjiga);
        if(odgovor.ok){
            window.location.href='/knjige';

        }else{
            let poruke='';
            for(const key in odgovor.poruka.errors){
                if(odgovor.poruka.errors.hasOwnProperty(key)){
                    poruke +=`${odgovor.poruka.errors[key]}` + '\n';
                }
            }
            alert(poruke);
        }

    }

    handleSubmit(e){
        e.preventDefault();
        const podaci= new FormData(e.target);

        this.dodajKnjigu({
            Naslov:podaci.get('Naslov'),
            Ime_Autora:podaci.get('Ime_Autora'),
            Prezime_Autora:podaci.get('Prezime_Autora'),
            Sazetak:podaci.get('Sazetak'),
            Br_stranica: parseInt(podaci.get('Br_stranica'))

        });
    }
    render(){
        return(
            <Container>
                <Form onSubmit={this.handleSubmit}>
                <Form.Group className="mb-3" controlId="Naslov">
            <Form.Label>Naslov</Form.Label>
            <Form.Control type="text" name="Naslov" placeholder="Naslov knjige" maxLength={255} required/>
          </Form.Group>


          <Form.Group className="mb-3" controlId="Sazetak">
            <Form.Label>Sazetak</Form.Label>
            <Form.Control type="text" name="Sazetak" placeholder="Sazetak" maxLength={300} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="Br_stranica">
            <Form.Label>Br_stranica</Form.Label>
            <Form.Control type="text" name="Br_stranica" placeholder="500" />
            <Form.Text className="text-muted">
             Ne smije biti negativan
            </Form.Text>
          </Form.Group>
           <Form onSubmit={this.handleSubmit}></Form>
          <Form.Group className="mb-3" controlId="Ime_Autora">
            <Form.Label>Ime_Autora</Form.Label>
            <Form.Control type="text" name="Ime autora" placeholder="Ime autora" maxLength={200} required />
          </Form.Group>

          <Form.Group className="mb-3" controlId="Prezime_Autora">
            <Form.Label>Prezime_Autora</Form.Label>
            <Form.Control type="text" name="Prezime autora" placeholder="Prezime autora" maxLength={200} required
          />
          </Form.Group>

          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/knjige`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Dodaj knjigu
            </Button>
            </Col>
          </Row>
         
                </Form>
            </Container>
        );
    }
}