import React, { Component } from "react";
import ClanDataService from "../../services/clan.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";




export default class PromijeniClana extends Component {

  constructor(props) {
    super(props);

    this.clan = this.dohvatiClana();
    this.PromijeniClana= this.PromijeniClana.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    
    


    this.state = {
      clan: {}
    };
  }


  async dohvatiClana() {
    // ovo mora bolje
    let href = window.location.href;
    let niz = href.split('/'); 
   await ClanDataService.getByID(niz[niz.length-1])
      .then(response => {
        this.setState({
          clan:response.data
        });
       // console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  async PromijeniClana(clan) {
    // ovo mora bolje
    let href = window.location.href;
    let niz = href.split('/'); 
    const odgovor =  await ClanDataService.put(niz[niz.length-1],clan);
    if(odgovor.ok){
      window.location.href='/clanovi';
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
    ///Object.keys(formData).forEach(fieldName => {
    //console.log(fieldName, formData[fieldName]);
    //})
    
    //console.log(podaci.get('status'));
    // You can pass formData as a service body directly:

    this.promijeniClana({
      Ime: podaci.get('Ime'),
      Prezime: podaci.get('Prezime'),
      Br_Iskaznice: podaci.get('Br_Iskaznice'),
      Status: podaci.get('Status')
    });
    
  }


  render() {
    
    const { clan} = this.state;

    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>


        <Form.Group className="mb-3" controlId="Ime">
            <Form.Label>Ime</Form.Label>
            <Form.Control type="text" name="Ime" placeholder="Josip" maxLength={255} defaultValue={clan.Ime} required/>
          </Form.Group>


          <Form.Group className="mb-3" controlId="Prezime">
            <Form.Label>Prezime</Form.Label>
            <Form.Control type="text" name="Prezime" placeholder="" defaultValue={clan.Prezime}  required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="Br_Iskaznice">
            <Form.Label>Br_Iskaznice</Form.Label>
            <Form.Control type="text" name="Br_Iskaznice" placeholder="" defaultValue={clan.Br_iskaznice}  />
          </Form.Group>

          <Form.Group className="mb-3" controlId="Status">
            <Form.Label>Status</Form.Label>
            <Form.Control type="text" name="Status" placeholder="" defaultValue={clan.Status}  />
          </Form.Group>

        
         
          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/clanovi`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Promijeni clana
            </Button>
            </Col>
          </Row>
        </Form>


      
    </Container>
    );
  }
}