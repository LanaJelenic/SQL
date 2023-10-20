import React, { Component } from "react";
import EvidencijaDataService from "../../services/evidencija.service";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import { Link } from "react-router-dom";
import { FaEdit } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';
import moment from 'moment';
import { Modal } from 'react-bootstrap';


export default class Evidencije extends Component {
  constructor(props) {
    super(props);
    /*const token = localStorage.getItem('Bearer');
    if(token=='null' || token===''){
      window.location.href='/';
    }*/
    this.dohvatiEvidencije = this.dohvatiEvidencije.bind(this);

    this.state = {
      evidencije: [],
      prikaziModal: false,
      zatvoriUspjesnoModal: false
    };
  }

  otvoriModal = () => this.setState({ prikaziModal: true });
  zatvoriModal = () => this.setState({ prikaziModal: false });
  otvoriUspjesnoModal = () => this.setState({ prikaziUspjesnoModal: true });
  zatvoriUspjesnoModal = () => this.setState({ prikaziUspjesnoModal: false });


  componentDidMount() {
    this.dohvatiEvidencije();
  }
  dohvatiEvidencije() {
    EvidencijaDataService.getAll()
      .then(response => {
        this.setState({
          evidencije: response.data
        });
        console.log(response);
      })
      .catch(e => {
        console.log(e);
      });
  }

  async obrisiEvidencije(id_posudbe){
    
    const odgovor = await EvidencijaDataService.delete(id_posudbe);
    if(odgovor.ok){
     this.dohvatiEvidencije();
     this.otvoriUspjesnoModal();
    }else{
     this.otvoriModal();
    }
    
   }

  render() {
    const { evidencije} = this.state;
    return (

    <Container>
      <a href="/evidencija/dodaj" className="btn btn-success gumb">Dodaj novu evidenciju</a>
      <Table striped bordered hover responsive>
              <thead>
                <tr>
                  <th>Clan</th>
                  <th>Datum posudbe</th>
                  <th>Datum vracanja</th>
                  <th> </th>
                </tr>
              </thead>
              <tbody>
              {evidencije && evidencije.map((g,index) => (
                
                <tr key={index}>
                  <td>{g.clan}</td>
                  <td className="Datum posudbe">
                    {g.datum_posudbe==null ? "Nije definirano" : moment.utc(g.datum_posudbe).format("DD. MM. YYYY. HH:mm")}
                  </td>
                  <td className="Datum vracanja"> 
                    {g.datum_vracanja==null?"Nije definirano":moment.utc(g.datum_vracanja).format("DD. MM. YYYY. HH:mm")}
                  </td>
                  <td>
                    <Row>
                      <Col>
                        <Link className="btn btn-primary gumb" to={`/evidencije/${g.id_posudbe}`}><FaEdit /></Link>
                      </Col>
                      <Col>
                        { 
                             <Button variant="danger"  className="gumb" onClick={() => this.obrisiEvidencije(g.id_posudbe)}><FaTrash /></Button>
                        }
                      </Col>
                    </Row>
                    
                  </td>
                </tr>
                ))
              }
              </tbody>
            </Table>     

             <Modal show={this.state.prikaziModal} onHide={this.zatvoriModal}>
              <Modal.Header closeButton>
                <Modal.Title>Greška prilikom brisanja</Modal.Title>
              </Modal.Header>
              <Modal.Body>Evidencija ima clanove.</Modal.Body>
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
              <Modal.Body>Evidencija uspjesno obrisana!</Modal.Body>
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