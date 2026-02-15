$(document).ready(() => {

    $('#country').on("change", async () => {
        const countryID = $('#country').find(":selected").val();
        const states = await getStates(Number(countryID));

        if (states.length <= 0) {
            return;
        }

        const stateSelect = $("#state")

        states.forEach((s) => {
            stateSelect.append(`<option value=${s.stateID}>${s.name}</option>`)
        })

    })
})

const getStates = async (id) => {
    if (id == 0) {
        return;
    }

    const res = await fetch("/ajax/GetStatesByCountryID?id=" + id);
    const states = await res.json();
    return states
}