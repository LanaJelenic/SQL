import React, { Component } from "react";
import PolaznikDataService from "../../services/clan.service";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import { Link } from "react-router-dom";
import { FaEdit } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';
import { Modal } from 'react-bootstrap';


export default class Clanovi extends Component {
  constructor(props) {
    super(props);
    this.dohvatiClanove = this.dohvatiClanove.bind(this);

    this.state = {
      clanovi: [],
      prikaziModal: false
    };
  }



  otvoriModal = () => this.setState({ prikaziModal: true });
  zatvoriModal = () => this.setState({ prikaziModal: false });

  componentDidMount() {
    this.dohvatiClanove();
  }
  dohvatiClanove() {
    ClanoviDataService.getAll()
      .then(response => {
        this.setState({
          clanovi: response.data
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  async obrisiClana(id_clana){
    
    const odgovor = await ClanoviDataService.delete(id_clana);
    if(odgovor.ok){
     this.dohvatiClanove();
    }else{
     // alert(odgovor.poruka);
      this.otvoriModal();
    }
    
   }

  render() {
    const { clanovi} = this.state;
    return (

    <Container>
      <a href="/clanovi/dodaj" className="btn btn-success gumb">Dodaj novog clana</a>
    <Row>
      { clanovi && clanovi.map((p) => (
           
           <Col key={p.id_clana} sm={12} lg={3} md={3}>

              <Card style={{ width: '18rem' }}>
                <Card.Body>
                  <Card.Title>{p.ime} {p.prezime}</Card.Title>
                  <Card.Text>
                    {p.br_iskaznice}
                  </Card.Text>
                  <Row>
                      <Col>
                      <Link className="btn btn-primary gumb" to={`/clanovi/${p.id_clana}`}><FaEdit /></Link>
                      </Col>
                      <Col>
                      <Button variant="danger" className="gumb"  onClick={() => this.obrisiClana(p.id_clana)}><FaTrash /></Button>
                      </Col>
                    </Row>
                </Card.Body>
              </Card>
            </Col>
          ))
      }
      </Row>


      <Modal show={this.state.prikaziModal} onHide={this.zatvoriModal}>
              <Modal.Header closeButton>
                <Modal.Title>Greška prilikom brisanja</Modal.Title>
              </Modal.Header>
              <Modal.Body>Clan se nalazi u evidenciji posudbe.</Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" onClick={this.zatvoriModal}>
                  Zatvori
                </Button>
              </Modal.Footer>
            </Modal>

    </Container>


    );
    
        }
}