chrome.webRequest.onAuthRequired.addListener(
    function (details, callbackFn) {
      callbackFn({
        authCredentials: { username: "qxibizrx", password: "ximfqfs33pyv" }
      });
    },
    { urls: ["<all_urls>"] },
    ['blocking']
  );
  