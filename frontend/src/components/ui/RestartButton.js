import React from 'react';
import '../../stylesheets/restartButton.css';
import { GAME_WON } from '../../constants';

export const RestartButton = (props) => {
    return (
        <div className="App-Restart">
            <button onClick={props.onClick}>
                {props.gameState === GAME_WON ? 'Play' : 'Try'} again
          </button>
        </div>
    );
}
