import React from "react";
import { LetterBlock, LettersRow } from "../ui";
import "../../stylesheets/virtualKeyboard.css";

export const VirtualKeyboard = props => {
  const renderRow = letters => {
    const children = letters
      .filter(letter => props.excluded.indexOf(letter) === -1)
      .map(letter => (
        <LetterBlock
          value={letter}
          onClick={() => props.onClick(letter)}
          key={`LetterBlock-${letter}`}
        />
      ));

    return <LettersRow>{children}</LettersRow>;
  };

  return (
    <div className="VirtualKeyboard">
      <div key="First" className="VirtualKeyboard-FirstRow">
        {renderRow(VirtualKeyboard.FIRST_ROW)}
      </div>
      <div key="Second" className="VirtualKeyboard-SecondRow">
        {renderRow(VirtualKeyboard.SECOND_ROW)}
      </div>
      <div key="Third" className="VirtualKeyboard-ThirdRow">
        {renderRow(VirtualKeyboard.THIRD_ROW)}
      </div>
    </div>
  );
};

VirtualKeyboard.FIRST_ROW = [
  "q",
  "w",
  "e",
  "r",
  "t",
  "y",
  "u",
  "i",
  "o",
  "p"
].map(x => x.toLocaleUpperCase());
VirtualKeyboard.SECOND_ROW = ["a", "s", "d", "f", "g", "h", "j", "k", "l"].map(
  x => x.toLocaleUpperCase()
);
VirtualKeyboard.THIRD_ROW = ["z", "x", "c", "v", "b", "n", "m"].map(x =>
  x.toLocaleUpperCase()
);
