import Entry from "./Entry";
import CreateEntry from "./CreateEntry";
import {add} from "../../api/entry/entryApi";

const Entries = (props) => {

    const simulateAddEntryServerCall = (entry) => {
        entry.date = (new Date()).toISOString();
    };

    const createEntry = (entry) => {
        add(entry);

        simulateAddEntryServerCall(entry);

        props.setEntries([...props.entries, entry]);
    };

    return (
        <>
        <CreateEntry createEntry={createEntry} />
        {props.entries.map((entry, i) => (
            <Entry key={i} {...entry} />
        ))}
        </>
    );
};
export default Entries;