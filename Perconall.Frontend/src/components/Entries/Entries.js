import Entry from "./Entry";
import CreateEntry from "./CreateEntry";
import {add} from "../../api/entry/entryApi";

const Entries = (props) => {
    return (
        <>
        <CreateEntry createEntry={add} />
        {props.entries.map((entry, i) => (
            <Entry key={i} {...entry} />
        ))}
        </>
    );
};
export default Entries;