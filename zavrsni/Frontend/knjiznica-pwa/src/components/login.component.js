import React, { useState } from "react";
import bcrypt from "bcryptjs";
import Container from "react-bootstrap/Container";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";

const LoginForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const hashiranaLozinka = "$2a$12$jhDN2pUMlqkJUrPkB.oNqO/zQttXSzyPwh4Duyukrm9ekmEs4wWXC";
  const kriptiranMail = "$2a$12$POgh02v2gJtpGNIQNN41aO.OcOTW.Cr3wXpm2lU0y9WyGYDVX2CGC";
  const secretKey =  "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY5ODE2NDAzOSwiaWF0IjoxNjk4MTY0MDM5fQ.nmkKobOHuu7NEqH9U899s-RRkzKsWxsRVnBzwjBamMA";

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      // Hash the user's password and compare it to the stored hash
      const isMatch = await bcrypt.compare(password, hashiranaLozinka);
      const eMailMatch = await bcrypt.compare(email, kriptiranMail);

      if (!isMatch || !eMailMatch ) {
        // Password is incorrect, throw an error
        alert("Password ili email neispravan");
        throw new Error("Incorrect password");
      }
      localStorage.setItem("token", JSON.stringify(secretKey));
      window.location.replace('/knjige');
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <Container className='mt-5'>
      <form onSubmit={handleSubmit}>
        <Form.Group className="mb-3">
          <Form.Label>Email</Form.Label>
          <Form.Control
            type="email"
            id="email"
            name="email"
            placeholder="e-mail"
            maxLength={255}
            value={email}
            onChange={(event) => setEmail(event.target.value)}
            required
          />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Lozinka</Form.Label>
          <Form.Control
            type="password"
            name="lozinka"
            id="password"
            value={password}
            onChange={(event) => setPassword(event.target.value)}
          />
        </Form.Group>
        <Button variant="primary" className="gumb" type="submit">
          Autoriziraj
        </Button>
      </form>
    </Container>
  );
};

export default LoginForm;
