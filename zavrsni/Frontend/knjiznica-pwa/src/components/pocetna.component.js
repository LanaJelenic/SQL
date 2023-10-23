import React,{Component} from "react";
import { Container } from "react-bootstrap";
import Card from 'react-bootstrap/Card';


export default class Pocetna extends Component{

    render(){
        return(
            <Container className="pocetna" align = 'center'> 
              <Card style={{ width: '30rem' }}>
              <Card.Img className="slika" variant="top"/>
                <Card.Body>
                  <Card.Text>
                 <h3> Dobrodošli u virtualnu knjižnicu!!</h3>
                  </Card.Text>
                </Card.Body>
              </Card>
                
            </Container>
        )
    }
}