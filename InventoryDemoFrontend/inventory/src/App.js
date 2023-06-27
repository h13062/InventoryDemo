import "./App.css";
import OperatorForm from "./components/Operators/Operator";
import NavbarComponent from "./components/Navbar/Navbar";

function App() {
  return (
    <div class="homePage">
      <NavbarComponent />
      <div class="formControl">{/* <OperatorForm /> */}</div>
    </div>
  );
}

export default App;
