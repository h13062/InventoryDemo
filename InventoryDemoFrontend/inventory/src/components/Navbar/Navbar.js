import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { Link } from "react-router-dom";
function NavbarComponent() {
  return (
    <Navbar bg="primary" data-bs-theme="dark">
      <Container>
        <Navbar.Brand href="#home">VISTA Container</Navbar.Brand>
        <Nav className="me-auto">
          <Nav.Link href="#home">Home</Nav.Link>
          <Nav.Link href="#accountants">For Accountants</Nav.Link>
          <Nav.Link href="#operators">For Operators</Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
}
export default NavbarComponent;
