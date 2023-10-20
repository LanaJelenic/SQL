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

  async PromijeniClana(id_clana, clan) {
    const odgovor =  await ClanDataService.put(id_clana,clan);
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
 

    this.PromijeniClana(podaci.get('Id_clana'),{
      ime: podaci.get('Ime'),
      prezime: podaci.get('Prezime'),
      br_Iskaznice: podaci.get('Br_Iskaznice'),
      status: podaci.get('Status') === 1 ? true : false
    });
    
  }


  render() {
    
    const { clan} = this.state;

    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>

        
        <Form.Group >
            <Form.Control type="text" name="Id_clana" defaultValue={clan.id_clana} hidden/>
          </Form.Group>

        <Form.Group className="mb-3" controlId="Ime">
            <Form.Label>Ime</Form.Label>
            <Form.Control type="text" name="Ime" placeholder="Josip" maxLength={255} defaultValue={clan.ime} required/>
          </Form.Group>


          <Form.Group className="mb-3" controlId="Prezime">
            <Form.Label>Prezime</Form.Label>
            <Form.Control type="text" name="Prezime" placeholder="" defaultValue={clan.prezime}  required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="Br_Iskaznice">
            <Form.Label>Br_Iskaznice</Form.Label>
            <Form.Control type="text" name="Br_Iskaznice" placeholder="" defaultValue={clan.br_Iskaznice}  />
          </Form.Group>

          <Form.Group className="mb-3" controlId="Status">
            <Form.Label>Status</Form.Label>
            <Form.Control type="text" name="Status" placeholder="1" defaultValue={clan.status ? '1' : '0'} />
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