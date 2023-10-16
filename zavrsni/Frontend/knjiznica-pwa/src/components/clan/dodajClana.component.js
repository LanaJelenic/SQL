import React, { Component } from "react";
import ClanDataService from "../../services/clan.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";


export default class DodajClana extends Component {

  constructor(props) {
    super(props);
    this.DodajClana = this.dodajClana.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  async dodajClana(knjiga) {
    const odgovor = await ClanDataService.post(knjiga);
    if(odgovor.ok){
      // routing na smjerovi
      window.location.href='/clanovi';
    }else{
      // pokaži grešku
      console.log(odgovor);
    }
  }



  handleSubmit(e) {
    e.preventDefault();
    const podaci = new FormData(e.target);

    this.dodajClana({
      Ime: podaci.get('Ime'),
      Prezime: podaci.get('Prezime'),
      Br_Iskaznice: podaci.get('Br_Iskaznice'),
      Status: podaci.get('Status')
    });
    
  }


  render() { 
    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>


          <Form.Group className="mb-3" controlId="Ime">
            <Form.Label>Ime</Form.Label>
            <Form.Control type="text" name="Ime" placeholder="Josip" maxLength={255} required/>
          </Form.Group>


          <Form.Group className="mb-3" controlId="Prezime">
            <Form.Label>Prezime</Form.Label>
            <Form.Control type="text" name="Prezime" placeholder="Horvat" required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="Br_Iskaznice">
            <Form.Label>Br_Iskaznice</Form.Label>
            <Form.Control type="text" name="Br_Iskaznice" placeholder=""/>
          </Form.Group>

          <Form.Group className="mb-3" controlId="Status">
            <Form.Label>Status</Form.Label>
            <Form.Control type="text" name="Status" placeholder="" />
          </Form.Group>

          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/clanovi`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Dodaj clana
            </Button>
            </Col>
          </Row>
         
          
        </Form>


      
    </Container>
    );
  }
}