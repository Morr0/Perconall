const Entry = (entry) => {
    return (
        <>
            <p>{entry.notes}</p>
            <p>Weight: {entry.kg}</p>
        </>
    );
};
export default Entry;