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
    this.dodajClana = this.dodajClana.bind(this);
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
      ime: podaci.get('ime'),
      prezime: podaci.get('prezime'),
      br_iskaznic: podaci.get('br_iskaznice'),
      status: podaci.get('status')
    });
    
  }


  render() { 
    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>


          <Form.Group className="mb-3" controlId="ime">
            <Form.Label>Ime</Form.Label>
            <Form.Control type="text" name="ime" placeholder="Josip" maxLength={255} required/>
          </Form.Group>


          <Form.Group className="mb-3" controlId="prezime">
            <Form.Label>Prezime</Form.Label>
            <Form.Control type="text" name="prezime" placeholder="Horvat" required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="br_iskaznice">
            <Form.Label>br_iskaznic</Form.Label>
            <Form.Control type="text" name="br_iskaznice" placeholder=""/>
          </Form.Group>

          <Form.Group className="mb-3" controlId="oib">
            <Form.Label>status</Form.Label>
            <Form.Control type="text" name="status" placeholder="" />
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