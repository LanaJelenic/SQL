import React,{Component} from "react";
import  Container  from "react-bootstrap/Container"
import  Nav  from "react-bootstrap/Nav";
import Navbar from 'react-bootstrap/Navbar';
import  NavDropdown  from "react-bootstrap/NavDropdown";

import logo from '../logo.svg';

export default class Izbornik extends Component{

    render(){
        return (

            <Navbar expand="lg" className="bg-body-tertiary">
            <Container className="containerIzbornika">
              <img className="App-logo" src={logo} alt=" " />
              <Nav.Link href="/"><h4>Virtualna knjižnica </h4> </Nav.Link>
              <Navbar.Toggle aria-controls="basic-navbar-nav" />
              <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="me-auto">
                  <NavDropdown title="Programi" id="basic-nav-dropdown">
                    <NavDropdown.Item href="/knjige">Knjige</NavDropdown.Item>
                    <NavDropdown.Item href="/clanovi">
                      Članovi
                    </NavDropdown.Item>
                    <NavDropdown.Item href="/evidencije">Evidencija posudbe</NavDropdown.Item>
                    <NavDropdown.Divider />
                    <NavDropdown.Item target="_blank" href="https://lanaaa-001-site1.ftempurl.com/swagger/index.html">
                      Swagger
                    </NavDropdown.Item>
                  </NavDropdown>
                </Nav>
              </Navbar.Collapse>
            </Container>
          </Navbar>



        );
}
}