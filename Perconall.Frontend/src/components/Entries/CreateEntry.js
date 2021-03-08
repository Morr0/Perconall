import {useState} from "react";

const CreateEntry = ({createEntry}) => {

    const [kg, setKg] = useState(20);
    const [notes, setNotes] = useState();
    const [onWakeup, setOnWakeup] = useState(false);
    const [onSleep, setOnSleep] = useState(false);

    // const 

    const onSubmit = (e) => {
        e.preventDefault();

        createEntry({
            kg,
            notes,
            onWakeup,
            onSleep
        });
    };
    
    return (
        <form onSubmit={(e) => onSubmit(e)}>
            <div className="form-group">
                <label htmlFor="kg">Weight (Kg): </label>
                <input name="kg" type="number" className="form-control" value={kg} min="20" max="1000" step="0.1" 
                onChange={(e) => setKg(e.target.value)} />
            </div>
            <div className="form-group">
                <label htmlFor="notes">Notes: </label>
                <textarea name="notes" className="form-control" value={notes} onChange={(e) => setNotes(e.target.value)}></textarea>
            </div>
            <div className="form-check">
                <input name="onWakeup" type="checkbox" className="form-check-input" value={onWakeup} 
                onChange={(e) => setOnWakeup(e.target.checked)}/>
                <label htmlFor="onWakeup" className="form-check-label">On Wakeup: </label>
            </div>
            <div className="form-check">
                <input name="onSleep" type="checkbox" className="form-check-input" value={onSleep} 
                onChange={(e) => setOnSleep(e.target.checked)} />
                <label htmlFor="onSleep" className="form-check-label">On Sleep: </label>
            </div>

            <button type="submit" className="btn btn-primary">Add Entry</button>
        </form>
    );
};
export default CreateEntry;