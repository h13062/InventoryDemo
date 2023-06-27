import "./App.css";
import OperatorForm from "./Pages/Operator/OperatorForm/Operator";
import NavbarComponent from "./components/Navbar/Navbar";
import AccountantForm from "./Pages/Accountant/AccountantForm/AccountantForm";
import HomePage from "./Pages/Home/Home";
import MachineInfo from "./Pages/Machine/MachineInfo/Machine";
import MaterialInfo from "./Pages/Material/MaterialInfo/Material";
import OperatorInfo from "./Pages/Operator/OperatorInfo/OperatorInfo";
import { BrowserRouter, Routes, Route } from "react-router-dom";
function App() {
  return (
    // <div class="homePage">
    //   <NavbarComponent />
    //   <div class="formControl">
    //     <OperatorForm />
    //     <AccountantForm />
    //   </div>
    // </div>

    <BrowserRouter>
      <div className="homePage">
        <NavbarComponent />
      </div>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/operatorform" index element={<OperatorForm />} />
        <Route path="/accountant" index element={<AccountantForm />} />
        <Route path="/machine" index element={<MachineInfo />} />
        <Route path="/material" index element={<MaterialInfo />} />
        <Route path="/operatorinfo" index element={<OperatorInfo />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
