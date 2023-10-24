import React, { Component } from "react";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import { Link } from "react-router-dom";
import { FaEdit } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';
import { Modal } from 'react-bootstrap';
import KnjigaDataService from "../../services/knjiga.service";


export default class Knjige extends Component {
  constructor(props) {
    super(props);
    // provjeri da li postoji token
    const token = localStorage.getItem('token');
    if(token === null || token===''){
      // preusmjeri korisnika na login stranicu
      window.location.replace('/');
    }

    this.dohvatiKnjigu = this.dohvatiKnjigu.bind(this);
    this.state = {
      knjige: [],
      prikaziModal: false,
      zatvoriUspjesnoModal: false
    };
  }



  otvoriModal = () => this.setState({ prikaziModal: true });
  zatvoriModal = () => this.setState({ prikaziModal: false });
  otvoriUspjesnoModal = () => this.setState({ prikaziUspjesnoModal: true });
  zatvoriUspjesnoModal = () => this.setState({ prikaziUspjesnoModal: false });

  

  componentDidMount() {
    this.dohvatiKnjigu();
  }
  dohvatiKnjigu() {
    KnjigaDataService.getAll()
      .then(response => {
        this.setState({
          knjige: response.data
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  async obrisiKnjigu(id_knjige){
    
    const odgovor = await KnjigaDataService.delete(id_knjige);
    if(odgovor.ok){
     this.dohvatiKnjigu();
     this.otvoriUspjesnoModal();
    }else{
    
      this.otvoriModal();
    }
    
   }

  render() {
    const { knjige} = this.state;

    return (

      <Container className='mt-5'>
      
    <Row>
      { knjige &&knjige.map((p) => (
           
           <Col key={p.id_knjige} sm={12} lg={3} md={3}>

              <Card style={{ width: '18rem' }}>
              <Card.Img variant="top" src={p.slika} />
                <Card.Body>
                  <Card.Title>{p.naslov}   </Card.Title>
                  <Card.Text>Autor: {p.ime_Autora} {p.prezime_Autora}</Card.Text>
                  <Card.Text>Sažetak:{p.sazetak}</Card.Text>
                  <Card.Text>
                    Broj stranica:{p.br_stranica} 
                  </Card.Text>
                 
                  <Row>
                      <Col>
                      <Link className="btn btn-primary gumb" to={`/knjige/${p.id_knjige}`}><FaEdit /></Link>
                      </Col>
                      <Col>
                      <Button variant="danger" className="gumb"  onClick={() => this.obrisiKnjigu(p.id_knjige)}><FaTrash /></Button>
                      </Col>
                    </Row>
                </Card.Body>
              </Card>
            </Col>
          ))
      }
      </Row>
      <a href="/knjige/dodaj" className="btn btn-success gumb">Dodaj novu knjigu</a>


      <Modal show={this.state.prikaziModal} onHide={this.zatvoriModal}>
              <Modal.Header closeButton>
                <Modal.Title>Greška prilikom brisanja</Modal.Title>
              </Modal.Header>
              <Modal.Body>Knjigu nije moguce obrisati jer se nalazi u evidenciji posudbe.</Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" onClick={this.zatvoriModal}>
                  Zatvori
                </Button>
              </Modal.Footer>
            </Modal>

           

            
      <Modal show={this.state.prikaziUspjesnoModal} onHide={this.zatvoriUspjesnoModal}>
              <Modal.Header closeButton>
                <Modal.Title>Uspješno brisanje</Modal.Title>
              </Modal.Header>
              <Modal.Body>Knjiga uspješno obrisana!!</Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" onClick={this.zatvoriUspjesnoModal}>
                  Zatvori
                </Button>
              </Modal.Footer>
            </Modal>

    </Container>


    );
    
        }
}