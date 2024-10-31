/// Created by Arthur Pliukh
/// Email: blackdogzx@gmail.com
/// Linkedin: https://www.linkedin.com/in/arthur-pliukh/
/// Facebook: https://www.facebook.com/DarkProgrammerr/

export const environment = {
  production: false,
  api: {
    url: "https://localhost:5268"
  },
  web: {
    url: "https://localhost:4200"
  },
  regexExpressions:
  {
    EMAIL_REGEXP: /^(?=.{1,254}$)(?=.{1,64}@)[-!#$%&'*+/0-9=?A-Z^_`a-z{|}~]+(\.[-!#$%&'*+/0-9=?A-Z^_`a-z{|}~]+)*@[A-Za-z0-9]([A-Za-z0-9-]{0,61}[A-Za-z0-9])?(\.[A-Za-z0-9]([A-Za-z0-9-]{0,61}[A-Za-z0-9])?)*$/,
    PASSWORD_REGEXP: /^(?=.*[a-zA-Z])(?=.*\d).+$/,
  },
};