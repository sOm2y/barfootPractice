import axios from 'axios'

axios.defaults.baseURL = 'http://barfootpractice20190812091136.azurewebsites.net/api'

export const login = user => {
	return new Promise((resolve, reject) => {
		axios({
			method: 'post',
			url: '/staffs/login',
			headers: {
				'Content-Type': 'application/json'
			},
			data: user
		})
			.then(res => {
				if (res.status === 400 || res.status === 403) {
					reject(res)
				}

				resolve(res.data)
			})
			.catch(err => {
				reject(err.response)
			})
	})
}
