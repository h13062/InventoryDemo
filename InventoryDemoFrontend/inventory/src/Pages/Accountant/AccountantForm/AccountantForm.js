import React from "react";
import { FormGroup, Label, Input } from "reactstrap";
import { Link } from "react-router-dom";

function AccountantForm() {
  return (
    <div>
      <h1>Accountant's Form</h1>
      <br />
      <FormGroup>
        <Label for="exampleSelect">Select</Label>
        <Input
          type="select"
          name="select"
          id="exampleSelect"
          placeholder="please input PO number"
        >
          <option>Please select your name</option>
          <option>Henry</option>
          <option>Tries</option>
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
          <Label>Product Code#</Label>
          <Input placeholder="please input Product Code" />
        </FormGroup>
        <br />
        <FormGroup>
          <Label>Order Number#</Label>
          <Input placeholder="please input Order Number" />
        </FormGroup>
        <br />
        <FormGroup>
          <Label>LOT#</Label>
          <Input placeholder="please input LOT number" />
        </FormGroup>
        <br />

        <FormGroup>
          <Label for="exampleDate">Order Date</Label>
          <Input
            type="date"
            name="date"
            id="exampleDate"
            placeholder="date placeholder"
          />
          <Input
            type="time"
            name="time"
            id="exampleTime"
            placeholder="time placeholder"
          />
        </FormGroup>
        <br />
        <FormGroup>
          <Label for="exampleDate">Due Date</Label>
          <Input
            type="date"
            name="date"
            id="exampleDate"
            placeholder="date placeholder"
          />
          <Input
            type="time"
            name="time"
            id="exampleTime"
            placeholder="time placeholder"
          />
        </FormGroup>
        <br />
        <FormGroup>
          <Label for="exampleDate">Shipped Date</Label>
          <Input
            type="date"
            name="date"
            id="exampleDate"
            placeholder="date placeholder"
          />
          <Input
            type="time"
            name="time"
            id="exampleTime"
            placeholder="time placeholder"
          />
        </FormGroup>
        <br />
      </FormGroup>

      <Link to="/">Back</Link>
    </div>
  );
}

export default AccountantForm;
