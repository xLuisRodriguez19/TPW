const ok = (data) => ({
    success: true,
    data
});

const fail = (err) => ({
    success: false,
    err
});

export {
    ok,
    fail
};
