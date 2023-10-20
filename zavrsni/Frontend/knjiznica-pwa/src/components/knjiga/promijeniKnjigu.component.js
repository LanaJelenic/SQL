import React, { Component } from "react";
import KnjigaDataService from "../../services/knjiga.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import Cropper from "react-cropper";
import "cropperjs/dist/cropper.css";
import { Image } from "react-bootstrap";



export default class PromijeniKnjigu extends Component {

  constructor(props) {
    super(props);

   
    this.knjiga = this.dohvatiKnjigu();
    this.promijeniKnjigu = this.PromijeniKnjigu.bind(this);
    this.spremiSliku=this.spremiSliku.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    

    this.state = {
      knjiga: {},
      trenutnaSlika:""
    };

  }



  async dohvatiKnjigu() {
    let href = window.location.href;
    let niz = href.split('/'); 
    await KnjigaDataService.getByID(niz[niz.length-1])
      .then(response => {
        this.setState({
          knjiga: response.data,
          trenutnaSlika:response.data.slika
        });
       
      })
      .catch(e => {
        console.log(e);
      });
    
   
  }

  async PromijeniKnjigu(id_knjige, knjiga) {
    let href = window.location.href;
    let niz = href.split('/'); 
    const odgovor = await KnjigaDataService.put(id_knjige,knjiga);
    if(odgovor.ok){
     
      window.location.href='/knjige';
    }else{
      
      console.log(odgovor);
    }
  }



  handleSubmit(e) {
    
    e.preventDefault();

    
    const podaci = new FormData(e.target);
    
    
  

    this.promijeniKnjigu(podaci.get('id_knjige'),{
      naslov: podaci.get('naslov'),
      ime_Autora: podaci.get('ime_Autora'),
      br_stranica: podaci.get('br_stranica'),
      prezime_Autora: podaci.get('prezime_Autora'),
      sazetak:podaci.get('sazetak')
      
    });
    
  }

  _crop(){
    this.setState({
      slikaServer:this.cropper.getCroppedCanvas().toDataURL()
    });
  }

  onCropperInit(cropper){
    this.cropper=cropper;
  }

  onChange=(e)=>{
    e.preventDefault();
    let files;
    if(e.dataTransfer){
      files = e.dataTransfer.files;
  }else if (e.target) {
    files = e.target.files;
  }
  const reader = new FileReader();
  reader.onload = () => {
    this.setState({
      image: reader.result
    });
  };
  try {
    reader.readAsDataURL(files[0]);
  } catch (error) {
    
  }
  
}
spremiSlikuAkcija = () =>{
  const { slikaServer} = this.state;
  const { knjiga} = this.state;

  this.spremiSliku(knjiga.id_knjige,slikaServer);
};

async spremiSliku(id_knjige,slika)
{
  let base64=slika;
  base64=base64.replace('data:image/png;base64,', '');
  const odgovor=await KnjigaDataService.postaviSliku(id_knjige,{
    base64:base64
  });
  if(odgovor.postaviSliku)
  {
    this.setState({
      trenutnaSlika:slika
    });
  }else{
    console.log(odgovor);
  }
}


  render() {
    
   const { knjiga} = this.state;
   const{image}=this.state;
   const{slikaServer}=this.state;
   const{trenutnaSlika}=this.state;


    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>
        <Row>
          <Col key="1" sm={12} lg={6} md={6}>

          <Form.Group >
            <Form.Control type="text" name="id_knjige" defaultValue={knjiga.id_knjige} hidden/>
          </Form.Group>
              <Form.Group className="mb-3" controlId="naslov">
                <Form.Label>Naslov</Form.Label>
                <Form.Control type="text" name="naslov" placeholder="" maxLength={255} defaultValue={knjiga.naslov} required/>
              </Form.Group>


              <Form.Group className="mb-3" controlId="ime_Autora">
                <Form.Label>Ime autora</Form.Label>
                <Form.Control type="text" name="ime_Autora" placeholder="" defaultValue={knjiga.ime_Autora}  required />
              </Form.Group>


              <Form.Group className="mb-3" controlId="prezime_Autora">
                <Form.Label>Prezime autora</Form.Label>
                <Form.Control type="text" name="prezime_Autora" placeholder="" defaultValue={knjiga.prezime_Autora}  />
              </Form.Group>

              <Form.Group className="mb-3" controlId="br_stranica">
                <Form.Label>Broj stranica</Form.Label>
                <Form.Control type="text" name="br_stranica" placeholder="" defaultValue={knjiga.br_stranica}  />
              </Form.Group>

              <Form.Group className="mb-3" controlId="sazetak">
                <Form.Label>Sažetak</Form.Label>
                <Form.Control type="text" name="sazetak" placeholder="" defaultValue={knjiga.sazetak}  />
              </Form.Group>
              
              <Row>
              <Col key="1" sm={12} lg={6} md={6}>
                Trenutna slika<br />
                <Image src={trenutnaSlika} className="slika"/>
                </Col>
                <Col key="2" sm={12} lg={6} md={6}>
                  Nova slika<br />
                <Image src={slikaServer} className="slika"/>
                </Col>
              </Row>

            </Col>
            <Col key="2" sm={12} lg={6} md={6}>
            <input type="file" onChange={this.onChange} />

             <input type="button" onClick={this.spremiSlikuAkcija} value={"Spremi sliku"} />

                <Cropper
                    src={image}
                    style={{ height: 400, width: "100%" }}
                    initialAspectRatio={1}
                    guides={true}
                    viewMode={1}
                    minCropBoxWidth={50}
                    minCropBoxHeight={50}
                    cropBoxResizable={false}
                    background={false}
                    responsive={true}
                    checkOrientation={false} 
                    crop={this._crop.bind(this)}
                    onInitialized={this.onCropperInit.bind(this)}
                />
        
            </Col>
            </Row>

       

          
         
          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/knjige`}>Odustani</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Promijeni knjigu
            </Button>
            </Col>
          </Row>
        </Form>


      
    </Container>
    );
  }
}
          