import React from "react";
import { Link } from "react-router-dom";

function HomePage() {
  return (
    <div className="homePage">
      <h1>Welcome to the Homepage!</h1>
      <div>
        <Link to="/operatorform">Go to Operator Form</Link>
      </div>
      <div>
        <Link to="/accountant">Go to Accountant Form</Link>
      </div>
      <div>
        <Link to="/machine">Go to Machine Manipulation Page</Link>
      </div>
      <div>
        <Link to="/material">Go to Material Manipulation Page</Link>
      </div>
      <div>
        <Link to="/operatorinfo">Go to Operator Manipulation Page</Link>
      </div>
    </div>
  );
}

export default HomePage;
