import React, { Component } from "react";
import EvidencijaDataService from "../../services/evidencija.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from 'moment';



export default class PromijeniEvidenciju extends Component {

  constructor(props) {
    super(props);
    // provjeri da li postoji token
    const token = localStorage.getItem('token');
    if(token === null || token===''){
      // preusmjeri korisnika na login stranicu
      window.location.replace('/');
    }

    this.evidencija = this.dohvatiEvidenciju();
    this.PromijeniEvidenciju = this.PromijeniEvidenciju.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
   
    this.state = {
     evidencija: {},
    
    };
  }

  async dohvatiEvidenciju() {
  
    let href = window.location.href;
    let niz = href.split('/'); 
    await EvidencijaDataService.getByID(niz[niz.length-1])
      .then(response => {
        this.setState({
          evidencija: response.data
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  async PromijeniEvidenciju(id_posudbe,evidencija) {
    const odgovor = await EvidencijaDataService.put(id_posudbe,evidencija);
    if(odgovor.ok){
      // routing na smjerovi
      window.location.href='/evidencije';
    }else{
      // pokaži grešku
      console.log(odgovor);
    }
  }


  handleSubmit(e) {
    e.preventDefault();
    const podaci = new FormData(e.target);

    this.PromijeniEvidenciju(podaci.get('id_posudbe'),{
      datum_posudbe: podaci.get('datum_posudbe'),
      datum_vracanja: podaci.get('datum_vracanja'),
      clan: podaci.get('clan'),
      idClana: podaci.get('idClana')
    });
  }


  render() { 

    const {evidencija} = this.state;

    return (
      <Container className='mt-5'>
        <Form onSubmit={this.handleSubmit}>


        <Form.Group >
            <Form.Control type="text" name="id_posudbe" defaultValue={evidencija.id_posudbe} hidden />
          </Form.Group>

          <Form.Group className="mb-3" controlId="idClana">
            <Form.Label>Id clana</Form.Label>
            <Form.Control type="text" name="idClana" placeholder="" defaultValue={evidencija.idClana}  maxLength={255} required/>
          </Form.Group>

          <Form.Group className="mb-3" controlId="clan">
            <Form.Label>Clan</Form.Label>
            <Form.Control type="text" name="clan" placeholder=""  defaultValue={evidencija.clan} maxLength={255} />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datum_posudbe">
            <Form.Label>Datum posudbe</Form.Label>
            <Form.Control type="date" name="datum_posudbe" placeholder="" defaultValue={moment.utc(evidencija.datumPosudbe).format("yyyy-MM-DD")}  />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datum_vracanja">
            <Form.Label>Datum vračanja</Form.Label>
            <Form.Control type="date" name="datum_vracanja" placeholder="" defaultValue={moment.utc(evidencija.datumPosudbe).format("yyyy-MM-DD")}   />
          </Form.Group>       
            


          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/evidencije`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Izmijeni evidenciju
            </Button>
            </Col>
          </Row>
        </Form>
    </Container>
    );
  }
}