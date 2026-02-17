$(document).ready(() => {
    setState();
    $('#country').on("change", async () => {
        setState();
    })
})

const setState = async () => {
    const countryID = $('#country').find(":selected").val();
    const states = await getStates(Number(countryID));

    let stateElement = $("#state")
    if (states.length <= 0) {
        stateElement.replaceWith(`<input id="state" name="UserAccountFormModel.StateName" asp-for="UserAccountFormModel.StateName" class="auth-input form-control" placeholder="State / Province" />`)
        return;
    }

    stateElement.empty();


    stateElement.replaceWith(`
            <select id="state" name="UserAccountFormModel.StateID" class="auth-input form-select">
                <option value="">Select State</option>
            </select>
        `);

    stateElement = $("#state");

    states.forEach((s) => {
        stateElement.append(`<option value=${s.stateID}>${s.name}</option>`)
    })


}

const getStates = async (id) => {

    if (id !== 39 && id != 233) {
        return [];
    }

    const res = await fetch("/ajax/GetStatesByCountryID?id=" + id);
    const states = await res.json();
    return states
}