import React, { Component } from "react";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import Button from "react-bootstrap/Button";
import { FaSignOutAlt } from "react-icons/fa";
import logo from "../logo.svg";
import { Modal } from 'react-bootstrap';

export default class Izbornik extends Component {
  constructor(props) {
    super(props);
    
    this.state = {
      prikaziModal: false
    };
  }

  otvoriModal = () => this.setState({ prikaziModal: true });
  zatvoriModal = () => this.setState({ prikaziModal: false });

  render() {
    return (
      <Navbar expand="lg" className="bg-body-tertiary mojIzbornik">
        <Container className="containerIzbornika">
          <img className="App-logo" src={logo} alt=" " />
          <Nav.Link href="/">
            <h4>Virtualna knjižnica </h4>{" "}
          </Nav.Link>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <NavDropdown title="Evidencije" id="basic-nav-dropdown">
                <NavDropdown.Item href="/knjige">Knjige</NavDropdown.Item>
                <NavDropdown.Item href="/clanovi">Članovi</NavDropdown.Item>
                <NavDropdown.Item href="/evidencije">
                  Evidencija posudbe
                </NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item
                  target="_blank"
                  href="https://lanaaa-001-site1.ftempurl.com/swagger/index.html"
                >
                  Swagger
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
          <Button
            alt="Log out"
            text="Log out"
            className="logoutBtn"
            variant="primary"
            size="sm"
            onClick={() => {
              localStorage.removeItem("token");
              this.otvoriModal();
            }}
          >
            <FaSignOutAlt />
          </Button>

          <Modal show={this.state.prikaziModal} onHide={this.zatvoriModal}>
              <Modal.Header closeButton>
                <Modal.Title>Uspješna odjava</Modal.Title>
              </Modal.Header>
              <Modal.Body>Hvala na posjeti našoj virtualnoj knjižnici.</Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" 
                  onClick={() => {
                    this.zatvoriModal();
                    window.location.replace("/");
                  }}
                  >
                  Zatvori
                </Button>
              </Modal.Footer>
            </Modal>

        </Container>
      </Navbar>
    );
  }
}
