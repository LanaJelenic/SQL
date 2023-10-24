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

    // provjeri da li postoji token
    const token = localStorage.getItem('token');
    if(token === null || token===''){
      // preusmjeri korisnika na login stranicu
      window.location.replace('/');
    }

    this.DodajClana = this.dodajClana.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  async dodajClana(clan) {
    const odgovor = await ClanDataService.post(clan);
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
      ime: podaci.get('ime'),
      prezime: podaci.get('prezime'),
      br_Iskaznice: podaci.get('br_Iskaznice'),
      status:  podaci.get('status') === 1 ? true : false
    });
    
  }


  render() { 
    return (
     <Container className='mt-5'>
        <Form onSubmit={this.handleSubmit}>


          <Form.Group className="mb-3" controlId="ime">
            <Form.Label>Ime</Form.Label>
            <Form.Control type="text" name="ime" placeholder="Josip" maxLength={255} required/>
          </Form.Group>


          <Form.Group className="mb-3" controlId="prezime">
            <Form.Label>Prezime</Form.Label>
            <Form.Control type="text" name="prezime" placeholder="Horvat" required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="br_Iskaznice">
            <Form.Label>br_Iskaznice</Form.Label>
            <Form.Control type="text" name="br_Iskaznice" placeholder=""/>
          </Form.Group>

          <Form.Group className="mb-3" controlId="Status">
            <Form.Label>status</Form.Label>
            <Form.Control type="text" name="status" placeholder="" />
          </Form.Group>

          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/clanovi`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Dodaj člana
            </Button>
            </Col>
          </Row>
         
          
        </Form>


      
    </Container>
    );
  }
}