import React from "react";
import { FormGroup, Label, Input } from "reactstrap";
import { Link } from "react-router-dom";

function OperatorForm() {
  return (
    <div>
      <h1>Operator Form</h1>
      <br />
      <FormGroup>
        <Label for="exampleSelect">Select</Label>
        <Input type="select" name="select" id="exampleSelect">
          <option>Please select your name</option>
          <option>Henry</option>
          <option>Try</option>
          <option>To</option>
          <option>Code</option>
          <option>This Up By Wednesday!!</option>
        </Input>
        <br />
        <FormGroup>
          <Label>PO#</Label>
          <Input placeholder="please input PO number" />
        </FormGroup>
        <br />

        <FormGroup>
          <Label>LOT#</Label>
          <Input placeholder="please input LOT number" />
        </FormGroup>
        <br />

        <FormGroup>
          <Label for="exampleDatetime">Datetime</Label>
          <Input
            type="datetime"
            name="datetime"
            id="exampleDatetime"
            placeholder="datetime placeholder"
          />
        </FormGroup>
        <br />

        <FormGroup>
          <Label for="exampleDate">Date</Label>
          <Input
            type="date"
            name="date"
            id="exampleDate"
            placeholder="date placeholder"
          />
        </FormGroup>
        <br />
        <FormGroup>
          <Label for="exampleTime">Time</Label>
          <Input
            type="time"
            name="time"
            id="exampleTime"
            placeholder="time placeholder"
          />
        </FormGroup>
      </FormGroup>

      <Link to="/">Back</Link>
    </div>
  );
}

export default OperatorForm;
