const Entry = (entry) => {
    return (
        <a href="#" className="list-group-item list-group-item-action">
            <div className="d-flex w-100 justify-content-between">
                <h5 className="mb-1">{entry.date}</h5>
                <span className="badge bg-primary rounded-pill">{entry.kg}</span>
            </div>
            <p className="mb-1">{entry.notes}</p>
        </a>
    );
};
export default Entry;