import {useState, useEffect} from "react";
import {getMany} from "../api/entry/entryApi";
import Entry from "../components/Entry";

const Home = () => {
    const [entries, setEntries] = useState([]);

    useEffect(() => {
        const getEntries = async () => setEntries(await getMany());

        getEntries();
        
    }, []);

    return (
        entries.map((entry, i) => (
            <Entry key={i} {...entry} />
        ))
    );
};

export default Home;