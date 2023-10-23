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
    const token = localStorage.getItem('Bearer');
    if(token=='null' || token===''){
      window.location.href='/';
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
        let g = response.data;
        g.datumPosudbe = moment.utc(g.datumPocetka).format("yyyy-MM-DD");
        g.datumVracanja = moment.utc(g.datumVracanja).format("yyyy-MM-DD");
        
        //console.log(g.vrijemePocetka);
        this.setState({
          evidencija: g
        });
       // console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  

  async PromijeniEvidenciju(evidencija) {
    const odgovor = await EvidencijaDataService.post(evidencija);
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
    console.log(podaci.get('datumPosudbe'));
    console.log(podaci.get('datumVracanja'));
    let datum = moment.utc(podaci.get('datumPosudbe') + ' ' + podaci.get('datumVracanja'));
    console.log(datum);

    
    
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
              <Link className="btn btn-danger gumb" to={`/evidencije`}>Odustani</Link>
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