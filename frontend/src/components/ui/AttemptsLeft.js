import React  from 'react';
import '../../stylesheets/attemptsLeft.css'

export const AttemptsLeft = (props) => {
    return (
        <div className="AttemptsLeft">
          <span>Retries left: <span className="AttemptsLeft-Number">
              {props.attempts}
            </span>
          </span>
        </div>
      );
}
