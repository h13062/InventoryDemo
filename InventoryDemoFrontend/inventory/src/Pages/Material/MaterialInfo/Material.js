import React, { useState } from "react";
import { FormGroup, Label, Input } from "reactstrap";
import { Link } from "react-router-dom";

function MaterialInfo() {
  const [materials, setMaterials] = useState([]);
  const [newMaterialName, setNewMaterialName] = useState("");
  const [searchMaterialId, setSearchMaterialId] = useState("");
  const [searchMaterial, setSearchMaterial] = useState(null);

  const apiUrl = "https://localhost:7290/api/Material";

  const handleGetAllMaterials = async () => {
    try {
      const response = await fetch(apiUrl);
      const data = await response.json();
      setMaterials(data);
    } catch (error) {
      console.error("Error fetching materials:", error);
    }
  };

  const handleAddMaterial = async () => {
    try {
      const response = await fetch(apiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ materialName: newMaterialName }),
      });
      const data = await response.json();
      setNewMaterialName(""); // Clear the input field after adding material
      console.log("New material added:", data);
    } catch (error) {
      console.error("Error adding material:", error);
    }
  };

  const handleSearchMaterial = async () => {
    try {
      const response = await fetch(`${apiUrl}/${searchMaterialId}`);
      if (response.ok) {
        const data = await response.json();
        setSearchMaterial(data);
      } else {
        setSearchMaterial(null);
        console.log(`Material with ID ${searchMaterialId} not found.`);
      }
    } catch (error) {
      console.error("Error searching material:", error);
    }
  };

  const handleDeleteMaterial = async (materialId) => {
    try {
      const response = await fetch(`${apiUrl}/${materialId}`, {
        method: "DELETE",
      });
      if (response.ok) {
        console.log(`Material with ID ${materialId} deleted.`);
        // Update the materials list after deletion
        handleGetAllMaterials();
      } else {
        console.log(`Material with ID ${materialId} not found.`);
      }
    } catch (error) {
      console.error("Error deleting material:", error);
    }
  };

  return (
    <div>
      <h1>Material Manipulation</h1>
      <br />
      <FormGroup>
        <Label>Add New Material</Label>
        <Input
          placeholder="Please enter new Material name"
          value={newMaterialName}
          onChange={(e) => setNewMaterialName(e.target.value)}
        />
      </FormGroup>
      <button onClick={handleAddMaterial}>Add Material</button>
      <br />
      <button onClick={handleGetAllMaterials}>Get All Materials</button>
      {materials.length > 0 && (
        <div>
          <h2>All Materials:</h2>
          <ul>
            {materials.map((material) => (
              <li key={material.materialId}>
                ID: {material.materialId}, Name: {material.materialName}
                <button
                  onClick={() => handleDeleteMaterial(material.materialId)}
                >
                  Delete
                </button>
              </li>
            ))}
          </ul>
        </div>
      )}
      <br />
      <h2>Search Material by ID:</h2>
      <FormGroup>
        <Label>Material ID:</Label>
        <Input
          placeholder="Enter Material ID"
          value={searchMaterialId}
          onChange={(e) => setSearchMaterialId(e.target.value)}
        />
      </FormGroup>
      <button onClick={handleSearchMaterial}>Search Material</button>
      {searchMaterial && (
        <div>
          <h2>Search Result:</h2>
          <p>
            ID: {searchMaterial.materialId}, Name: {searchMaterial.materialName}
            <button
              onClick={() => handleDeleteMaterial(searchMaterial.materialId)}
            >
              Delete
            </button>
          </p>
        </div>
      )}
      {!searchMaterial && searchMaterialId && (
        <p>Material with ID {searchMaterialId} not found.</p>
      )}
      <Link to="/">Back</Link>
    </div>
  );
}

export default MaterialInfo;
