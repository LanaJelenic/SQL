import React, { Component } from "react";
import EvidencijaDataService from "../../services/evidencija.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from 'moment';
import Table from 'react-bootstrap/Table';
import { FaTrash } from 'react-icons/fa';

import { AsyncTypeahead } from 'react-bootstrap-typeahead';


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
   
    const { evidencija} = this.state;
    
    


    const obradiTrazenje = (uvjet) => {
      this.traziPolaznik( uvjet);
    };

    const odabraniPolaznik = (polaznik) => {
      //console.log(grupa.sifra + ' - ' + polaznik[0].sifra);
      if(polaznik.length>0){
        this.dodajPolaznika(grupa.sifra, polaznik[0].sifra);
      }
     
    };

    return (
    <Container>
       
        <Form onSubmit={this.handleSubmit}>
          <Row>
          <Col key="1" sm={12} lg={6} md={6}>
              <Form.Group className="mb-3" controlId="naziv">
                <Form.Label>Naziv</Form.Label>
                <Form.Control type="text" name="naziv" placeholder="" maxLength={255} defaultValue={grupa.naziv}  required/>
              </Form.Group>

              <Form.Group className="mb-3" controlId="smjer">
                <Form.Label>Smjer</Form.Label>
                <Form.Select defaultValue={grupa.sifraSmjer}  onChange={e => {
                  this.setState({ sifraSmjer: e.target.value});
                }}>
                {smjerovi && smjerovi.map((smjer,index) => (
                      <option key={index} value={smjer.sifra}>{smjer.naziv}</option>

                ))}
                </Form.Select>
              </Form.Group>

              <Form.Group className="mb-3" controlId="datumPocetka">
                <Form.Label>Datum početka</Form.Label>
                <Form.Control type="date" name="datumPocetka" placeholder="" defaultValue={grupa.datumPocetka}  />
              </Form.Group>

              <Form.Group className="mb-3" controlId="vrijeme">
                <Form.Label>Vrijeme</Form.Label>
                <Form.Control type="time" name="vrijeme" placeholder="" defaultValue={grupa.vrijemePocetka}  />
              </Form.Group>

            



              <Row>
                <Col>
                  <Link className="btn btn-danger gumb" to={`/grupe`}>Odustani</Link>
                </Col>
                <Col>
                <Button variant="primary" className="gumb" type="submit">
                  Promjeni grupu
                </Button>
                </Col>
              </Row>
          </Col>
          <Col key="2" sm={12} lg={6} md={6} className="polazniciGrupa">
          <Form.Group className="mb-3" controlId="uvjet">
                <Form.Label>Traži polaznika</Form.Label>
                
          <AsyncTypeahead
            className="autocomplete"
            id="uvjet"
            emptyLabel="Nema rezultata"
            searchText="Tražim..."
            labelKey={(polaznik) => `${polaznik.prezime} ${polaznik.ime}`}
            minLength={3}
            options={pronadeniPolaznici}
            onSearch={obradiTrazenje}
            placeholder="dio imena ili prezimena"
            renderMenuItemChildren={(polaznik) => (
              <>
                <span>{polaznik.prezime} {polaznik.ime}</span>
              </>
            )}
            onChange={odabraniPolaznik}
          />
          </Form.Group>
          <Table striped bordered hover responsive>
              <thead>
                <tr>
                  <th>Polaznik</th>
                  <th>Akcija</th>
                </tr>
              </thead>
              <tbody>
              {polaznici && polaznici.map((polaznik,index) => (
                
                <tr key={index}>
                  <td > {polaznik.ime} {polaznik.prezime}</td>
                  <td>
                  <Button variant="danger"   onClick={() => this.obrisiPolaznika(grupa.sifra, polaznik.sifra)}><FaTrash /></Button>
                    
                  </td>
                </tr>
                ))
              }
              </tbody>
            </Table>    
          </Col>
          </Row>

          
         
          
        </Form>


      
    </Container>
    );
  }
}