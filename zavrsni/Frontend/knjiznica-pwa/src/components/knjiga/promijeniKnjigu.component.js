import React, { Component } from "react";
import KnjigaDataService from "../../services/knjiga.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";



export default class PromijeniKnjigu extends Component {

  constructor(props) {
    super(props);

   
    this.knjiga = this.dohvatiKnjigu();
    this.promijeniKnjigu = this.PromijeniKnjigu.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    

    this.state = {
      knjiga: {}
    };

  }



  async dohvatiKnjigu() {
    let href = window.location.href;
    let niz = href.split('/'); 
    await KnjigaDataService.getByID(niz[niz.length-1])
      .then(response => {
        this.setState({
          knjiga: response.data
        });
       // console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
    
   
  }

  async promijeniKnjigu(knjiga) {
    // ovo mora bolje
    let href = window.location.href;
    let niz = href.split('/'); 
    const odgovor = await KnjigaDataService.put(niz[niz.length-1],knjiga);
    if(odgovor.ok){
      // routing na smjerovi
      window.location.href='/knjige';
    }else{
      // pokaži grešku
      console.log(odgovor);
    }
  }



  handleSubmit(e) {
    // Prevent the browser from reloading the page
    e.preventDefault();

    // Read the form data
    const podaci = new FormData(e.target);
    //Object.keys(formData).forEach(fieldName => {
    // console.log(fieldName, formData[fieldName]);
    //})
    
    //console.log(podaci.get('verificiran'));
    // You can pass formData as a service body directly:

    this.promijeniKnjigu({
      naslov: podaci.get('Naslov'),
      ime_Autora: podaci.get('Ime_Autora'),
      br_stranica: podaci.get('Br_stranica'),
      prezime_Autora: podaci.get('Prezime_Autora'),
      sazetak:podaci.get('Sazetak')
    });
    
  }


  render() {
    
   const { knjiga} = this.state;


    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>


          <Form.Group className="mb-3" controlId="Naslov">
            <Form.Label>Naslov</Form.Label>
            <Form.Control type="text" name="Naslov" placeholder="Naslov knjige"
            maxLength={255} defaultValue={knjiga.naslov} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="Br_stanica">
            <Form.Label>Br_stranica</Form.Label>
            <Form.Control type="text" name="Br_stranica" defaultValue={knjiga.br_stranica}  placeholder="130" />
          </Form.Group>

          <Form.Group className="mb-3" controlId="Ime_Autora">
            <Form.Label>Ime autora</Form.Label>
            <Form.Control type="text" name="Ime autora" placeholder="Ime autora"
            maxLength={255} defaultValue={knjiga.ime_autora} required />
          </Form.Group>

          <Form.Group className="mb-3" controlId="Prezime_Autora">
            <Form.Label>Prezime autora</Form.Label>
            <Form.Control type="text" name="Prezime autora" placeholder="Prezime autora"
            maxLength={255} defaultValue={knjiga.prezime_autora} required />
          </Form.Group>
          

          <Form.Group className="mb-3" controlId="Sazetak">
            <Form.Label>Sazetak</Form.Label>
            <Form.Control type="text" name="Sazetak" placeholder="Sazetak"
            maxLength={255} defaultValue={knjiga.sazetak} required />
          </Form.Group>
          

        
         
          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/knjige`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Promjeni knjigu
            </Button>
            </Col>
          </Row>
        </Form>


      
    </Container>
    );
  }
}