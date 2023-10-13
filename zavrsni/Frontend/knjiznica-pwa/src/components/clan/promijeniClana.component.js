import React, { Component } from "react";
import PolaznikDataService from "../../services/clan.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";




export default class PromjeniClana extends Component {

  constructor(props) {
    super(props);

    this.clan = this.dohvatiClana();
    this.promjeniClana= this.promjeniClana.bind(this);
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

  async promijeniClana(clan) {
    // ovo mora bolje
    let href = window.location.href;
    let niz = href.split('/'); 
    const odgovor = await ClanDataService.put(niz[niz.length-1],clan);
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
    //Object.keys(formData).forEach(fieldName => {
    // console.log(fieldName, formData[fieldName]);
    //})
    
    //console.log(podaci.get('verificiran'));
    // You can pass formData as a service body directly:

    this.promijeniClana({
      ime: podaci.get('ime'),
      prezime: podaci.get('prezime'),
      br_iskaznice: podaci.get('br_iskaznice'),
      status: podaci.get('status')
    });
    
  }


  render() {
    
    const { clan} = this.state;

    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>


        <Form.Group className="mb-3" controlId="ime">
            <Form.Label>Ime</Form.Label>
            <Form.Control type="text" name="ime" placeholder="Josip" maxLength={255} defaultValue={clan.ime} required/>
          </Form.Group>


          <Form.Group className="mb-3" controlId="prezime">
            <Form.Label>Prezime</Form.Label>
            <Form.Control type="text" name="prezime" placeholder="" defaultValue={clan.prezime}  required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="br_iskaznice">
            <Form.Label>br_iskaznice</Form.Label>
            <Form.Control type="text" name="br_iskaznice" placeholder="" defaultValue={clan.br_iskaznice}  />
          </Form.Group>

          <Form.Group className="mb-3" controlId="status">
            <Form.Label>status</Form.Label>
            <Form.Control type="text" name="status" placeholder="" defaultValue={clan.status}  />
          </Form.Group>

        
         
          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/clanovi`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Promjeni clana
            </Button>
            </Col>
          </Row>
        </Form>


      
    </Container>
    );
  }
}