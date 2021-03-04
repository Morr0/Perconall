import AddEntry from "./AddEntry";

// TODO extract hardcoding
const url = "http://localhost:5000/api/v1/entry";

export const add = async (addEntry) => {
    if (!(addEntry instanceof AddEntry)) throw new Error("Must pass AddEntry object");

    await fetch(url, {
        method: "POST",
        body: JSON.stringify(addEntry),
        headers: {
            "Content-Type": "application/json"
        }
    });
};

export const getMany = async () => {
    const res = await fetch(url, {
        "Accept": "application/json"
    });
    
    const entries = await res.json();
    return entries;
};
