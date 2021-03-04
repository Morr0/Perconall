import Entry from "./Entry";

const Entries = (props) => {
    console.log(props)
    return (
        props.entries.map((entry, i) => (
            <Entry key={i} {...entry} />
        ))
    );
};
export default Entries;