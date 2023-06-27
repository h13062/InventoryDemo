import React, { useState, useEffect } from "react";
import { FormGroup, Label, Input } from "reactstrap";
import { Link } from "react-router-dom";

function OperatorForm() {
  const [currentTime, setCurrentTime] = useState("");

  useEffect(() => {
    const intervalId = setInterval(() => {
      const now = new Date();
      const hours = String(now.getHours()).padStart(2, "0");
      const minutes = String(now.getMinutes()).padStart(2, "0");
      const time = `${hours}:${minutes}`;
      setCurrentTime(time);
    }, 1000);

    return () => {
      clearInterval(intervalId);
    };
  }, []);
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
            value={currentTime}
            readOnly
          />
        </FormGroup>
      </FormGroup>

      <Link to="/">Back</Link>
    </div>
  );
}

export default OperatorForm;
