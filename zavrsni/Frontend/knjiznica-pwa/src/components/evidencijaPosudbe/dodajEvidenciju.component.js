import React, { Component } from "react";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from 'moment';
import EvidencijaDataService from "../../services/evidencija.service";



export default class DodajEvidenciju extends Component {

  constructor(props) {
    super(props);
    this.DodajEvidenciju = this.dodajEvidenciju.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  async dodajEvidenciju(evidencija) {
    console.log('dodajem');
  const odgovor = await EvidencijaDataService.post(evidencija);
  if(odgovor.ok){
    window.location.href='/evidencije';
  }else{
    // pokaži grešku
    console.log(odgovor);
  }
}

  handleSubmit(e) {
    e.preventDefault();
    const podaci = new FormData(e.target);
  
    this.dodajEvidenciju({
      datum_posudbe: podaci.get('datum_posudbe'),
      datum_vracanja: podaci.get('datum_vracanja'),
      idClana: podaci.get('idClana')
    });
    
  }


  render() { 
    const formattedDate = moment().format('MMMM Do YYYY, h:mm:ss a');
    console.log(formattedDate.to);  // e.g., "September 25th 2023, 12:53:05 pm"
    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>


          <Form.Group className="mb-3" controlId="idClana">
            <Form.Label>Id clana</Form.Label>
            <Form.Control type="nuber" name="idClana" placeholder="" maxLength={255} required/>
          </Form.Group>

          <Form.Group className="mb-3" controlId="datum_posudbe">
            <Form.Label>Datum posudbe</Form.Label>
            <Form.Control type="date" name="datum_posudbe" placeholder=""  />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datum_vracanja">
            <Form.Label>Datum vračanja</Form.Label>
            <Form.Control type="date" name="datum_vracanja" placeholder=""  />
          </Form.Group>       

          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/grupe`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Dodaj evidenciju
            </Button>
            </Col>
          </Row>
        </Form>
    </Container>
    );
  }
}
