import React, { useState } from "react";
import { FormGroup, Label, Input } from "reactstrap";
import { Link } from "react-router-dom";

function MachineInfo() {
  const [machines, setMachines] = useState([]);
  const [newMachineName, setNewMachineName] = useState("");
  const [searchMachineId, setSearchMachineId] = useState("");
  const [searchMachine, setSearchMachine] = useState(null);

  const apiUrl = "https://localhost:7290/api/Machine";

  const handleGetAllMachines = async () => {
    try {
      const response = await fetch(apiUrl);
      const data = await response.json();
      setMachines(data);
    } catch (error) {
      console.error("Error fetching machines:", error);
    }
  };

  const handleAddMachine = async () => {
    try {
      const response = await fetch(apiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ machineName: newMachineName }),
      });
      const data = await response.json();
      setNewMachineName(""); // Clear the input field after adding machine
      console.log("New machine added:", data);
    } catch (error) {
      console.error("Error adding machine:", error);
    }
  };

  const handleSearchMachine = async () => {
    try {
      const response = await fetch(`${apiUrl}/${searchMachineId}`);
      if (response.ok) {
        const data = await response.json();
        setSearchMachine(data);
      } else {
        setSearchMachine(null);
        console.log(`Machine with ID ${searchMachineId} not found.`);
      }
    } catch (error) {
      console.error("Error searching machine:", error);
    }
  };

  const handleDeleteMachine = async (machineId) => {
    try {
      const response = await fetch(`${apiUrl}/${machineId}`, {
        method: "DELETE",
      });
      if (response.ok) {
        console.log(`Machine with ID ${machineId} deleted.`);
        // Update the machines list after deletion
        handleGetAllMachines();
      } else {
        console.log(`Machine with ID ${machineId} not found.`);
      }
    } catch (error) {
      console.error("Error deleting machine:", error);
    }
  };

  return (
    <div>
      <h1>Machine Manipulation</h1>
      <br />
      <FormGroup>
        <Label>Add New Machine</Label>
        <Input
          placeholder="Please enter new Machine name"
          value={newMachineName}
          onChange={(e) => setNewMachineName(e.target.value)}
        />
      </FormGroup>
      <button onClick={handleAddMachine}>Add Machine</button>
      <br />
      <button onClick={handleGetAllMachines}>Get All Machines</button>
      {machines.length > 0 && (
        <div>
          <h2>All Machines:</h2>
          <ul>
            {machines.map((machine) => (
              <li key={machine.machineId}>
                ID: {machine.machineId}, Name: {machine.machineName}
                <button onClick={() => handleDeleteMachine(machine.machineId)}>
                  Delete
                </button>
              </li>
            ))}
          </ul>
        </div>
      )}
      <br />
      <h2>Search Machine by ID:</h2>
      <FormGroup>
        <Label>Machine ID:</Label>
        <Input
          placeholder="Enter Machine ID"
          value={searchMachineId}
          onChange={(e) => setSearchMachineId(e.target.value)}
        />
      </FormGroup>
      <button onClick={handleSearchMachine}>Search Machine</button>
      {searchMachine && (
        <div>
          <h2>Search Result:</h2>
          <p>
            ID: {searchMachine.machineId}, Name: {searchMachine.machineName}
            <button
              onClick={() => handleDeleteMachine(searchMachine.machineId)}
            >
              Delete
            </button>
          </p>
        </div>
      )}
      {!searchMachine && searchMachineId && (
        <p>Machine with ID {searchMachineId} not found.</p>
      )}
      <Link to="/">Back</Link>
    </div>
  );
}

export default MachineInfo;
