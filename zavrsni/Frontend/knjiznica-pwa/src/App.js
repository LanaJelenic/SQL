import React from "react";
import './App.css';
import {
  BrowserRouter as Router,Routes,Route
} from "react-router-dom";
import Izbornik from './components/izbornik.component';
import Pocetna from './components/pocetna.component';
import NadzornaPloca from './components/nadzornaploca.component';
import Clanovi from './components/clan/clanovi.component';
import DodajClana from './components/clan/dodajClana.component';
import PromijeniClana from './components/clan/promijeniClana.component';
import Knjige from './components/knjiga/knjige.component';
import DodajKnjigu from './components/knjiga/dodajKnjigu.components';
import PromijeniKnjigu from './components/knjiga/promijeniKnjigu.component';



export default function App() {
  return (
    <Router>
      <Izbornik/>
      <Routes>
      <Route path='/' element={<Pocetna/>}/>
      <Route path='/nadzornaploca' element={<NadzornaPloca />}/>
        <Route path="/knjige" element={<Knjige />} />
        <Route path="/knjige/dodaj" element={<DodajKnjigu />} />
        <Route path="/knjige/:id_knjige" element={<PromijeniKnjigu />} />
        <Route path='/clanovi' element={<Clanovi />} />
        <Route path="/clanovi/dodaj" element={<DodajClana />} />
        <Route path="/clanovi/:id_clana" element={<PromijeniClana />} />
      </Routes>
    </Router>
  );
}
