import React from "react";
import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Izbornik from "./components/izbornik.component";
import Clanovi from "./components/clan/clanovi.component";
import DodajClana from "./components/clan/dodajClana.component";
import PromijeniClana from "./components/clan/promijeniClana.component";
import Knjige from "./components/knjiga/knjige.component";
import DodajKnjigu from "./components/knjiga/dodajKnjigu.components";
import PromijeniKnjigu from "./components/knjiga/promijeniKnjigu.component";
import Evidencija from "./components/evidencijaPosudbe/evidencije.component";
import DodajEvidenciju from "./components/evidencijaPosudbe/dodajEvidenciju.component";
import PromijeniEvidenciju from "./components/evidencijaPosudbe/promijeniEvidenciju.component";
import LoginForm from "./components/login.component";

function requireAuth(nextState, replace) {
 window.location.replace('/clanovi');
}

export default function App() {
  return (
    <Router>
      <Izbornik />
      <Routes>
        <Route path="/" element={<LoginForm />} />
        <Route path="/knjige" element={<Knjige />}  onEnter={requireAuth} />
        <Route path="/knjige/dodaj" element={<DodajKnjigu />} />
        <Route path="/knjige/:id_knjige" element={<PromijeniKnjigu />} />
        <Route path="/clanovi" element={<Clanovi />} />
        <Route path="/clanovi/dodaj" element={<DodajClana />} />
        <Route path="/clanovi/:id_clana" element={<PromijeniClana />} />
        <Route path="/evidencije" element={<Evidencija />} />
        <Route path="/evidencija/dodaj" element={<DodajEvidenciju />} />
        <Route path="/evidencije/:id_posudbe"element={<PromijeniEvidenciju />}/>
      </Routes>
    </Router>
  );
}
