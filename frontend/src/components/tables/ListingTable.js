import React from 'react'
import { Table, Divider, Tag } from 'antd';

const { Column, ColumnGroup } = Table;

const stubData = [
    {
        "listingId": 1,
        "address": "11 auckland street, auckland, 1010",
        "price": 1200000.0,
        "status": "open",
        "confidentialNote": "buyer expectation is under 1m.",
        "created": "2019-08-12T20:28:33.9066667"
    },
    {
        "listingId": 2,
        "address": "12 auckland street, auckland, 1010",
        "price": 1200000.0,
        "status": "open",
        "confidentialNote": "buyer expectation is under 1m.",
        "created": "2019-08-12T20:28:33.91"
    },
    {
        "listingId": 3,
        "address": "13 auckland street, auckland, 1010",
        "price": 1200000.0,
        "status": "open",
        "confidentialNote": "buyer expectation is under 1m.",
        "created": "2019-08-12T20:28:33.9166667"
    }
]

const Listing = ({ ...props }) => {
    return (<Table dataSource={stubData}>

        <Column title="Price" dataIndex="price" key="price" />
        <Column title="Address" dataIndex="address" key="address" />
        <Column title="Created" dataIndex="created" key="created" />
        <Column
            title="Status"
            dataIndex="status"
            key="status"
            render={status => (
                <span>

                    <Tag color="blue" >
                        {status}
                    </Tag>

                </span>
            )}
        />
        <Column
            title="Action"
            key="action"
            render={(text, record) => (
                <span>
                    <a href="javascript:;">Update</a>
                    <Divider type="vertical" />
                    <a href="javascript:;">Delete</a>
                </span>
            )}
        />
    </Table>)
}

export default Listing