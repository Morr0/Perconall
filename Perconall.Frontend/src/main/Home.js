import {useState, useEffect} from "react";
import {getMany} from "../api/entry/entryApi";
import Entries from "../components/Entries/Entries";

const Home = () => {
    const [entries, setEntries] = useState([]);

    useEffect(() => {
        const getEntries = async () => setEntries(await getMany());

        getEntries();
        
    }, []);

    return (
        <div className="container">
            <div className="col"></div>
            <div className="col">
                <Entries entries={entries} setEntries={setEntries} />
            </div>
            <div className="col"></div>
        </div>
    );
};

export default Home;