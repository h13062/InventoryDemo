import React, { useState } from "react";
import { FormGroup, Label, Input } from "reactstrap";
import { Link } from "react-router-dom";

function OperatorInfo() {
  const [operators, setOperators] = useState([]);
  const [newOperatorName, setNewOperatorName] = useState("");
  const [searchOperatorId, setSearchOperatorId] = useState("");
  const [searchOperator, setSearchOperator] = useState(null);

  const apiUrl = "https://localhost:7290/api/Operator";

  const handleGetAllOperators = async () => {
    try {
      const response = await fetch(apiUrl);
      const data = await response.json();
      setOperators(data);
    } catch (error) {
      console.error("Error fetching operators:", error);
    }
  };

  const handleAddOperator = async () => {
    try {
      const response = await fetch(apiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ operatorName: newOperatorName }),
      });
      const data = await response.json();
      setNewOperatorName(""); // Clear the input field after adding operator
      console.log("New operator added:", data);
    } catch (error) {
      console.error("Error adding operator:", error);
    }
  };

  const handleSearchOperator = async () => {
    try {
      const response = await fetch(`${apiUrl}/${searchOperatorId}`);
      if (response.ok) {
        const data = await response.json();
        setSearchOperator(data);
      } else {
        setSearchOperator(null);
        console.log(`Operator with ID ${searchOperatorId} not found.`);
      }
    } catch (error) {
      console.error("Error searching operator:", error);
    }
  };

  const handleDeleteOperator = async (operatorId) => {
    try {
      const response = await fetch(`${apiUrl}/${operatorId}`, {
        method: "DELETE",
      });
      if (response.ok) {
        console.log(`Operator with ID ${operatorId} deleted.`);
        // Update the operators list after deletion
        handleGetAllOperators();
      } else {
        console.log(`Operator with ID ${operatorId} not found.`);
      }
    } catch (error) {
      console.error("Error deleting operator:", error);
    }
  };

  return (
    <div>
      <h1>Operator Manipulation</h1>
      <br />
      <FormGroup>
        <Label>Add New Operator</Label>
        <Input
          placeholder="Please enter new Operator name"
          value={newOperatorName}
          onChange={(e) => setNewOperatorName(e.target.value)}
        />
      </FormGroup>
      <button onClick={handleAddOperator}>Add Operator</button>
      <br />
      <button onClick={handleGetAllOperators}>Get All Operators</button>
      {operators.length > 0 && (
        <div>
          <h2>All Operators:</h2>
          <ul>
            {operators.map((operator) => (
              <li key={operator.operatorId}>
                ID: {operator.operatorId}, Name: {operator.operatorName}
                <button
                  onClick={() => handleDeleteOperator(operator.operatorId)}
                >
                  Delete
                </button>
              </li>
            ))}
          </ul>
        </div>
      )}
      <br />
      <h2>Search Operator by ID:</h2>
      <FormGroup>
        <Label>Operator ID:</Label>
        <Input
          placeholder="Enter Operator ID"
          value={searchOperatorId}
          onChange={(e) => setSearchOperatorId(e.target.value)}
        />
      </FormGroup>
      <button onClick={handleSearchOperator}>Search Operator</button>
      {searchOperator && (
        <div>
          <h2>Search Result:</h2>
          <p>
            ID: {searchOperator.operatorId}, Name: {searchOperator.operatorName}
            <button
              onClick={() => handleDeleteOperator(searchOperator.operatorId)}
            >
              Delete
            </button>
          </p>
        </div>
      )}
      {!searchOperator && searchOperatorId && (
        <p>Operator with ID {searchOperatorId} not found.</p>
      )}
      <Link to="/">Back</Link>
    </div>
  );
}

export default OperatorInfo;
